using Oqtane.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Services
{
    /// <summary>
    /// Service to manage <see cref="Theme"/> entries
    /// </summary>
    public interface IThemeService
    {

        /// <summary>
        /// Returns a list of available themes
        /// </summary>
        /// <returns></returns>
        Task<List<Theme>> GetThemesAsync();

        /// <summary>
        /// Returns a specific theme
        /// </summary>
        /// <param name="themeId"></param>
        /// <param name="siteId"></param>
        /// <returns></returns>
        Task<Theme> GetThemeAsync(int themeId, int siteId);

        /// <summary>
        /// Returns a theme <see cref="ThemeControl"/>s containing a specific theme control type
        /// </summary>
        /// <param name="themes"></param>
        /// <param name="themeControlType"></param>
        /// <returns></returns>
        Theme GetTheme(List<Theme> themes, string themeControlType);

        /// <summary>
        /// Returns a list of <see cref="ThemeControl"/>s from the given themes
        /// </summary>
        /// <param name="themes"></param>
        /// <returns></returns>
        List<ThemeControl> GetThemeControls(List<Theme> themes);

        /// <summary>
        /// Returns a list of <see cref="ThemeControl"/>s for a theme containing a specific theme control type
        /// </summary>
        /// <param name="themes"></param>
        /// <param name="themeControlType"></param>
        /// <returns></returns>
        List<ThemeControl> GetThemeControls(List<Theme> themes, string themeControlType);

        /// <summary>
        /// Returns a list of containers (<see cref="ThemeControl"/>) for a theme containing a specific theme control type
        /// </summary>
        /// <param name="themes"></param>
        /// <param name="themeControlType"></param>
        /// <returns></returns>
        List<ThemeControl> GetContainerControls(List<Theme> themes, string themeControlType);

        /// <summary>
        /// Updates a existing theme
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        Task UpdateThemeAsync(Theme theme);

        /// <summary>
        /// Deletes a theme
        /// </summary>
        /// <param name="themeName"></param>
        /// <returns></returns>
        Task DeleteThemeAsync(string themeName);

        /// <summary>
        /// Creates a new theme
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        Task<Theme> CreateThemeAsync(Theme theme);

        /// <summary>
        /// Returns a list of theme templates (<see cref="Template"/>)
        /// </summary>
        /// <returns></returns>
        Task<List<Template>> GetThemeTemplatesAsync();


        /// <summary>
        /// Returns a list of layouts (<see cref="ThemeControl"/>) from the given themes with a matching theme name
        /// </summary>
        /// <param name="themes"></param>
        /// <param name="themeName"></param>
        /// <returns></returns>
        List<ThemeControl> GetLayoutControls(List<Theme> themes, string themeName);
    }
}
